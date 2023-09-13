import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi} from '../Interfaces/response-api';
import { environment } from 'src/environments/environment.prod';
import { Client} from '../Interfaces/client';


@Injectable({
  providedIn: 'root'
})
export class RolService {

  private urlAPI:string = environment.endPoint+"Rol/";

  constructor(private http:HttpClient) {}

  List():Observable<ResponseApi>{

    return this.http.get<ResponseApi>(`${this.urlAPI}List`);
  }

  Save(request : Client):Observable<ResponseApi>
  {
    return this.http.post<ResponseApi>(`${this.urlAPI}Save`,request);
  };

  Edit(request : Client):Observable<ResponseApi>
  {
    return this.http.put<ResponseApi>(`${this.urlAPI}Edit`,request);
  };

  Delete(id : number):Observable<ResponseApi>
  {
    return this.http.delete<ResponseApi>(`${this.urlAPI}Delete/${id}`)
  }




}
