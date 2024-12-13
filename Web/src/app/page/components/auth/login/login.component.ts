import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { PasswordModule } from 'primeng/password';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { AuthService } from 'src/app/page/service/auth.service';
import { helperCore } from 'src/app/page/service/CORE';
import { LoginService } from 'src/app/page/service/login.service';

@Component({
    selector: 'app-login',
    standalone: true,
    imports: [FormsModule,PasswordModule,CheckboxModule,ButtonModule],
    templateUrl: './login.component.html',   
    styles: [`
        :host ::ng-deep .pi-eye,
        :host ::ng-deep .pi-eye-slash {
            transform:scale(1.6);
            margin-right: 1rem;
            color: var(--primary-color) !important;
        }
    `]
    
})
export class LoginComponent {

  constructor(private authService: AuthService,private login_service: LoginService,private router: Router){}
  ngOnInit(): void {
    localStorage.clear()
  }
  logiObj: any = {
    "username": "",
    "password": ""
  };

  onLogin() {
    console.log(this.logiObj)
    if(this.logiObj.username == ""){
      alert("Please enter username")
      return;
    }
    if(this.logiObj.password == ""){
      alert("Please enter password")
      return;
    }
    this.login_service.onLogin(this.logiObj.username,this.logiObj.password).subscribe((data:any)=>{
      if(data.status == "ok"){
        // const user = JSON.stringify(data.data)
        // localStorage.setItem("_u",helperCore.encode(user))
        localStorage.setItem("username", this.logiObj.username);
        localStorage.setItem("_ut",helperCore.encode(data.data.token))
        //localStorage.setItem("_ut",helperCore.decode(JSON.stringify(data.data.token)))
        this.router.navigate(['/dashboard'])
      }
      else{
        alert(data.message)
      }
    })
  }
}
