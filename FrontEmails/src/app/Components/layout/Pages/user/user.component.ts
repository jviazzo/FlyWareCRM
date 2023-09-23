import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/Services/user.service';
import { UtilityService } from 'src/app/Reusable/utility.service';
import { User } from 'src/app/Interfaces/user';
import { ModalUserComponent } from '../../Modals/modal-user/modal-user.component';
import { NgModule, } from '@angular/core';
import Swal from 'sweetalert2';




@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit, AfterViewInit {
  colTable: string[] = [
    'FullName',
    'Email',
    'RolDescription',
    'Status',
    'Actions',
  ];
  initDate: User[] = [];
  userDataList = new MatTableDataSource(this.initDate);
  @ViewChild(MatPaginator) paginationTable!: MatPaginator;


  constructor(
    private dialog: MatDialog,
    private _userService: UserService,
    private _utilityService: UtilityService
  ) {}



  ngOnInit(): void {
    this.GetUsers();
  }

  ngAfterViewInit(): void {
    this.userDataList.paginator = this.paginationTable;
  }

  GetUsers() {
    this._userService.List().subscribe({
      next: (data) => {
        if (data.status) {
          this.userDataList.data = data.value;
        } else {
          this._utilityService.showAlert('Users not found', 'Oops!');
        }
      },
      error: (e) => {
        console.log(e);
      },
    });
  }


  UseFilterInTable(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.userDataList.filter = filterValue.trim().toLowerCase();
  }

  NewUser() {
    this.dialog
      .open(ModalUserComponent, {
        disableClose: true,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'true') this.GetUsers();
      });
  }
  EditUser(user: User) {
    this.dialog
      .open(ModalUserComponent, {
        disableClose: true,
        data: user,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'true') this.GetUsers();
      });
  }

  DeleteUser(user: User) {
    Swal.fire({
      title: '¿Do you want to delete the user?',
      text: user.fullName,
      icon: 'warning',
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'Yes, Delete',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No, Back',
    }).then((result) => {
      if (result.isConfirmed) {
        this._userService.Delete(user.idUser).subscribe({
          next: (responseData) => {
            if (responseData.status) {
              this._utilityService.showAlert(
                'the user has been deleted',
                'Ready'
              );
              this.GetUsers();
            } else
              this._utilityService.showAlert('Could not delete user', 'Error');
          },
          error: (e) => {},
        });
      }
    });


  }


}
