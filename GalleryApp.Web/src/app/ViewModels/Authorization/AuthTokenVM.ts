export interface AuthTokenVM {
  value: string;
  dateCreated: Date;
  ipAddress: string;
  account: {
    id: number;
    username: string;
    password: string;
  };
}
