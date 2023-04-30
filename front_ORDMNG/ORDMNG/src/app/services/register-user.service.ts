import { Injectable } from '@angular/core';
import { UserComponent } from '../user/user.component';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterUserService {
 
  registerUrl = "http://localhost:55277/api/Users";

  constructor(public objcHttp:HttpClient) { }

  registerList: UserComponent[];
  registerData: RegisterUserService=new RegisterUserService();
  role:string="";


  getregister() { 
    this.objcHttp.get(this.registerUrl).toPromise().then(res => this.registerList = res as UserComponent[])
  }

  postregister() {
    this.registerData.UserType.push(this.role);
    console.log(this.registerData)
    return this.objcHttp.post(this.registerUrl, this.registerData);
  }

  putregister() {
    return this.objcHttp.put(this.registerUrl + "/" + this.registerData.UserId, this.registerData)
  }

  delregister(UserId) {
    return this.objcHttp.delete(this.registerUrl + "/" + UserId);
  }
}
