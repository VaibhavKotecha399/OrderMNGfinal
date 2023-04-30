import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(/*public auth: RegisterService,*/ private fb: FormBuilder, /*private auth1: AuthorizeService,*/ public http: HttpClient,
  private router: Router) { }

  ngOnInit(): void {
  }

}
