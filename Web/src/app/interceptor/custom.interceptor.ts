import { HttpInterceptorFn } from '@angular/common/http';
import { helperCore } from '../page/service/CORE';

export const customInterceptor: HttpInterceptorFn = (req, next) => {
  if(localStorage.getItem('_ut') != null){
    const token =helperCore.decode(localStorage.getItem('_ut'))
    const clonedReq = req.clone({
      setHeaders:{
        Authorization: `${token}`
      }
    })
    return next(clonedReq);
  }
  return next(req.clone({
     
  }));
  
};
