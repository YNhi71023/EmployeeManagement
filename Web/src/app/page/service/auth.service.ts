import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _username: string = '';

  setUsername(username: string): void {
    this._username = username;
  }

  getUsername(): string {
    return this._username;
  }
}
