// import { Injectable } from '@angular/core';
// import { CanActivate,  Router } from '@angular/router';
// @Injectable({
//   providedIn: 'root'
// })
// export class AuthGuard implements CanActivate {
//   constructor( private router: Router) {}
//   canActivate(): boolean {
//     const token = localStorage.getItem("_ut")  
//     if (!token) {
//       this.router.navigate(['']);
//       return false;
//     }
    
//     return true;  
//   }
// };
import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = () => {
  const router = inject(Router);
  const token = localStorage.getItem("_ut");
  console.log('AuthGuard is running');
  if (!token) {
    router.navigate(['']);
    return false;
  }
  
  return true;
};
