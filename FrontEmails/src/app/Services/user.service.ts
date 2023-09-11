  import { Injectable } from '@angular/core';
  import { HttpClient } from '@angular/common/http';
  import { Observable } from 'rxjs';
  import { ResponseApi} from '../Interfaces/response-api';
  import { Login} from '../Interfaces/login';
  import { User} from '../Interfaces/user';
import { environment } from 'src/environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private urlAPI:string = environment.endPoint+"User/";

  constructor(private http:HttpClient) {}

  Login (request : Login):Observable<ResponseApi>
  {
    return this.http.post<ResponseApi>(`${this.urlAPI}Login`,request);
  };
//https://localhost:7226/api/User/Login
  List():Observable<ResponseApi>{

    return this.http.get<ResponseApi>(`${this.urlAPI}List`);
  }

  Save(request : User):Observable<ResponseApi>
  {
    return this.http.post<ResponseApi>(`${this.urlAPI}Save`,request);
  };

  Edit(request : User):Observable<ResponseApi>
  {
    return this.http.put<ResponseApi>(`${this.urlAPI}Edit`,request);
  };

  Delete(id : number):Observable<ResponseApi>
  {
    return this.http.delete<ResponseApi>(`${this.urlAPI}Delete/${id}`)
  }
}
