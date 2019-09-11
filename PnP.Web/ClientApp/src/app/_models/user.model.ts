
export interface ApplicationUser {
  FirstName: string;
  LastName: string;
  IdNumber: string;
  IdentificationType: string;
  UserType: string;
  Status: string;
}

export interface SignInModel {
  Username: string;
  Password: string;
}

export interface SignInViewModel {
  Id: string;
  token: string;
}

export interface UserToCreate {
  FirstName: string;
  LastName: string;
  IdNumber: string;
  Email: string;
  Password: string;
  ConfirmPassword: string;
  IsSubscribed: boolean;
  IdentificationTypeId: number;
}

export interface SignUpViewModel {
  Status: string;
  Message: string;
  User: User;
}

export interface User {
  userId: string;
  FirstName: string;
  LastName: string;
  IdNumber: string;
  Email: string;
  Username: string;
}

export interface IdentificationType {
  Id: string;
  Title: string;
}
