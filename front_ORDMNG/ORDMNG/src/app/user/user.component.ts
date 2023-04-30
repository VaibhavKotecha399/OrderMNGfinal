import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterUserService } from '../services/register-user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(public obj:RegisterUserService,public router:Router) { }

  ngOnInit(): void { this.resetForm()
  }

  resetForm(form?:NgForm){
    if(form!=null){
      form.form.reset();
    }
    else{
      this.obj.registerData={UserId:0,FirstName:'',LastName:'',UserType:'',Email:'',UserPassword:'',UserAddress:'',UserEmail:'',Phone:''}
    }
}
}