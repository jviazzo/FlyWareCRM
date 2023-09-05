import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi} from '../Interfaces/response-api';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private urlAPI:string = environment.endPoint+"Category/";

  constructor(private http:HttpClient) {}


  List():Observable<ResponseApi>{

    return this.http.get<ResponseApi>(`${this.urlAPI}List`);
  }




}
