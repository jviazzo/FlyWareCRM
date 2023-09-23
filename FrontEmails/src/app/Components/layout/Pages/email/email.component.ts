import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { ClientService } from 'src/app/Services/client.service';
import { UtilityService } from 'src/app/Reusable/utility.service';
import { UserService } from 'src/app/Services/user.service';

import { Email } from 'src/app/Interfaces/email';
import { Client } from 'src/app/Interfaces/client';
import { DetailEmail } from 'src/app/Interfaces/detail-email';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css']
})

export class EmailComponent implements OnInit{


  listClients:Client[] = [];
  listClientFilter:Client[] = [];
  constructor(){}

  ngOnInit(): void {
  }

}





