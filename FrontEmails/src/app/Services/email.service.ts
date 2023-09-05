import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi} from '../Interfaces/response-api';
import { environment } from 'src/environments/environment.prod';
import { Email } from '../Interfaces/email';

@Injectable({
  providedIn: 'root'
})
export class RolService {

  private urlAPI:string = environment.endPoint+"Email/";

  constructor(private http:HttpClient) {}

  Save(request : Email):Observable<ResponseApi>
  {
    return this.http.post<ResponseApi>(`${this.urlAPI}Save`,request);
  };

  EmailLog(searchBy:string,specialIdEmail:string,dateIni:string,dateEnd:string):Observable<ResponseApi>
  {
    return this.http.get<ResponseApi>(`${this.urlAPI}Email Log?searchBy${searchBy}&specialIdEmail$
    {specialIdEmail}&dateIni${dateIni}&dateEnd${dateEnd}}`);
  };

  Report(dateIni:string,dateEnd:string):Observable<ResponseApi>
  {
    return this.http.get<ResponseApi>(`${this.urlAPI}Report?dateIni${dateIni}&dateEnd${dateEnd}}`);
  };

}
