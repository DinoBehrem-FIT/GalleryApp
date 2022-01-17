import { UserVM } from '../User/UserVM';

export interface ExhibitionVM {
  title: string;
  description: string;
  startingDate: Date;
  organizer: UserVM;
}
