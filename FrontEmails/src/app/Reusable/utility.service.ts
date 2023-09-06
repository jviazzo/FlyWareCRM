import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Session } from '../Interfaces/session';


@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor(private _snackBar:MatSnackBar) { }


  showAlert(message:string, type:string){
    this._snackBar.open(message,type,{
      horizontalPosition:"end",
      verticalPosition:"top",
      duration:3000
    })
  }

  SaveUserSession(userSession:Session){
    localStorage.setItem("user",JSON.stringify(userSession));
  }

  GetUserSession()
  {
    const stringDate = localStorage.getItem("user");
    const user = JSON.parse(stringDate!);
    return user;
  }


  DeleteUserSesion()
  {
    localStorage.removeItem("user");
  }

}
