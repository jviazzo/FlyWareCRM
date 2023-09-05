import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi} from '../Interfaces/response-api';
import { environment } from 'src/environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class DashBoardService {


  private urlAPI:string = environment.endPoint+"DashBoard/";

  constructor(private http:HttpClient) {}

  Summary():Observable<ResponseApi>{

    return this.http.get<ResponseApi>(`${this.urlAPI}Summary`);
  }

}
