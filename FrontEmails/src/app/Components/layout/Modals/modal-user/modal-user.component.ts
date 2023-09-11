import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Rol } from 'src/app/Interfaces/rol';
import { User } from 'src/app/Interfaces/user';
import { RolService } from 'src/app/Services/client.service';
import { UserService } from 'src/app/Services/user.service';
import { UtilityService } from 'src/app/Reusable/utility.service';

@Component({
  selector: 'app-modal-user',
  templateUrl: './modal-user.component.html',
  styleUrls: ['./modal-user.component.css'],
})
export class ModalUserComponent {
  formUser: FormGroup;
  encryptPass: boolean = true;
  actionTitle: string = 'Add';
  actionButton: string = 'Save';
  rolList: Rol[] = [];

  constructor(
    private modalAct: MatDialogRef<ModalUserComponent>,
    @Inject(MAT_DIALOG_DATA) public userDate: User,
    private fbuilder: FormBuilder,
    private _rolService: RolService,
    private _userService: UserService,
    private _utilityService: UtilityService
  ) {

    this.formUser = this.fbuilder.group({
      fullName :['',Validators.required],
      email :['',Validators.required],
      idRol :['',Validators.required],
      password :['',Validators.required],
      isActive :['1',Validators.required]


    })

    if(this.userDate != null)
    {
      this.actionTitle = "Edit";
      this.actionButton = "Update";
    }

    this._rolService.List().subscribe({
      next:(data) => {
        if(data.status) this.rolList = data.value;
      },
      error:(e) =>{}
    })

  }
  ngOninit() : void{
    if(this.userDate != null)
    {
      this.formUser.patchValue({
        fullName : this.userDate.fullName,
        email :this.userDate.email,
        idRol :this.userDate.idRol,
        password :this.userDate.password,
        isActive :this.userDate.isActive.toString()
      })
    }
  }

  saveEditUser(){
    const _user: User = {
      idUser : this.userDate == null ? 0 : this.userDate.idUser,
      fullName : this.formUser.value.fullName,
      email : this.formUser.value.email,
      idRol : this.formUser.value.idRol,
      rolDescription:"",
      password : this.formUser.value.password,
      isActive : parseInt(this.formUser.value.isActive)
    }

    if(this.userDate == null)
    {
      this._userService.Save(_user).subscribe({
        next:(data) => {
          if(data.status)
          {
            this._utilityService.showAlert("User has save","Succes");
            this.modalAct.close("true");
          }else
          this._utilityService.showAlert("Couldn't save user","Failed");
        },
        error:(e) =>{}
      })
    }else
    {
      this._userService.Edit(_user).subscribe({
        next:(data) => {
          if(data.status)
          {
            this._utilityService.showAlert("User has edit","Succes");
            this.modalAct.close("true");
          }else
          this._utilityService.showAlert("Couldn't edit user","Failed");
        },
        error:(e) =>{}
      })

    }


  }



}

