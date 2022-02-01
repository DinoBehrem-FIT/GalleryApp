import { AccountVM } from './AccountVM';

export interface AuthTokenVM {
  id: number;
  value: string;
  account: AccountVM;
  accountId: number;
  dateCreated: Date;
  ipAddress: string;
}
