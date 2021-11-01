export interface User{
  userName? :string;
  email?:string;
  password?:string;
  mobile?:string;
}

export interface userForLogin{
  userName: string;
  password: string;
  token: string;
}
