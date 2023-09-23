import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Client } from 'src/app/Interfaces/client';
import { ClientService } from 'src/app/Services/client.service';
import { UtilityService } from 'src/app/Reusable/utility.service';
import { CategoryService } from 'src/app/Services/category.service';
import { Category } from 'src/app/Interfaces/category';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-modal-client',
  templateUrl: './modal-client.component.html',
  styleUrls: ['./modal-client.component.css'],
})
export class ModalClientComponent {
  formClient: FormGroup;
  actionTitle: string = 'Add';
  actionButton: string = 'Save';
  categoryList: Category[] = [];


  constructor(
    private modalAct: MatDialogRef<ModalClientComponent>,
    @Inject(MAT_DIALOG_DATA) public clientData: Client,
    private fbuilder: FormBuilder,
    private _clientService: ClientService,
    private _utilityService: UtilityService,
    private _categoryService : CategoryService
  ) {

    if(clientData)
    {

      this.formClient = this.fbuilder.group({
        name :[clientData.name,Validators.required],
        idCategory :[clientData.idCategory,Validators.required],
        categoryDescription :[clientData.categoryDescription,Validators.required],
        email :[clientData.email,Validators.required],
        company :[clientData.company,Validators.required],
        language :[clientData.language,Validators.required],
        isActive :['1',Validators.required]
    });
    }else
    {

      this.formClient = this.fbuilder.group({
        name :['',Validators.required],
        idCategory :['',Validators.required],
        categoryDescription :['',Validators.required],
        email :['',Validators.required],
        company :['',Validators.required],
        language :['',Validators.required],
        isActive :['1',Validators.required]});

    }

    if(this.clientData != null)
    {
      this.actionTitle = "Edit";
      this.actionButton = "Update";
    }

    this._categoryService.List().subscribe({
      next:(data) => {
        if(data.status) this.categoryList = data.value;
      },
      error:(e) =>{}
    })

  }
  ngOninit() : void{
    if(this.clientData != null)
    {
      this.formClient.patchValue({
        name : this.clientData.name,
        email :this.clientData.email,
        idCategory :this.clientData.idCategory,
        company :this.clientData.company,
        language :this.clientData.language,
        isActive :this.clientData.isActive.toString()
      })
    }
  }

  saveEditClient(){
    const _client: Client = {
      idClient : this.clientData == null ? 0 : this.clientData.idClient,
      name : this.formClient.value.name,
      email : this.formClient.value.email,
      idCategory : this.formClient.value.idCategory,
      categoryDescription:"",
      company : this.formClient.value.company,
      language : this.formClient.value.language,
      isActive : parseInt(this.formClient.value.isActive)
    }

    if(this.clientData == null)
    {
      this._clientService.Save(_client).subscribe({
        next:(data) => {
          if(data.status)
          {
            this._utilityService.showAlert("Client has save","Succes");
            this.modalAct.close("true");
          }else
          this._utilityService.showAlert("Couldn't save client","Failed");
        },
        error:(e) =>{}
      })
    }else
    {
      this._clientService.Edit(_client).subscribe({
        next:(data) => {
          if(data.status)
          {
            this._utilityService.showAlert("Client has edit","Succes");
            this.modalAct.close("true");
          }else
          this._utilityService.showAlert("Couldn't edit client","Failed");
        },
        error:(e) =>{}
      })

    }


  }



}

