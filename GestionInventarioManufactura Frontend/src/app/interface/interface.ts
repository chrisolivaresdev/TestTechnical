export interface Login {
  email:string,
  password:string
}

export interface Register {
  name:string,
  email:string,
  password:string
}

export interface Product {
  id:number,
  name:string,
  typeElaboration:string
  status:string
}

export interface Getproduct {
  data:Product[],
  totalItems:number,
  pageNumber:number,
  pageSize:number
}

export interface ApiResponse {
  isSuccess:boolean,
  msj:string,
}

export interface AuthResponse {
  isSuccess:boolean,
  token:string,
}


