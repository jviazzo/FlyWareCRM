import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatDialog } from '@angular/material/dialog';
import { UtilityService } from 'src/app/Reusable/utility.service';
import { NgModule, } from '@angular/core';
import Swal from 'sweetalert2';
import { Client } from 'src/app/Interfaces/client';
import { ClientService } from 'src/app/Services/client.service';
import { ModalClientComponent } from '../../Modals/modal-client/modal-client.component';




@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit, AfterViewInit {
  colTable: string[] = [
    'FullName',
    'Email',
    'RolDescription',
    'Company',
    'Languages',
    'Status',
    'Actions',
  ];
  initDate: Client[] = [];
  clientDataList = new MatTableDataSource(this.initDate);
  @ViewChild(MatPaginator) paginationTable!: MatPaginator;


  constructor(
    private dialog: MatDialog,
    private _clientService: ClientService,
    private _utilityService: UtilityService
  ) {}



  ngOnInit(): void {
    this.GetClients();
  }

  ngAfterViewInit(): void {
    this.clientDataList.paginator = this.paginationTable;
  }

  GetClients() {
    this._clientService.List().subscribe({
      next: (data) => {
        if (data.status) {
          this.clientDataList.data = data.value;
        } else {
          this._utilityService.showAlert('Clients not found', 'Oops!');
        }
      },
      error: (e) => {
        console.log(e);
      },
    });
  }


  UseFilterInTable(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.clientDataList.filter = filterValue.trim().toLowerCase();
  }

  NewClient() {
    this.dialog
      .open(ModalClientComponent, {
        disableClose: true,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'true') this.GetClients();
      });
  }
  EditClient(client: Client) {
    this.dialog
      .open(ModalClientComponent, {
        disableClose: true,
        data: client,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'true') this.GetClients();
      });
  }

  DeleteClient(client: Client) {
    Swal.fire({
      title: '¿Do you want to delete the client?',
      text: client.name,
      icon: 'warning',
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'Yes, Delete',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No, Back',
    }).then((result) => {
      if (result.isConfirmed) {
        this._clientService.Delete(client.idClient).subscribe({
          next: (responseData) => {
            if (responseData.status) {
              this._utilityService.showAlert(
                'the user has been deleted',
                'Ready'
              );
              this.GetClients();
            } else
              this._utilityService.showAlert('Could not delete user', 'Error');
          },
          error: (e) => {},
        });
      }
    });


  }


}
