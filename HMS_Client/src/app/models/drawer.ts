export class Drawer {
  constructor(
    public drawerID?: number,
    public drawerNo?: string,
    public drawerCondition?: number,
    public isOccupied?: boolean,
    public morgueID?: number,
    public morgue?: null
  ) { }
}
export enum drawerCondition {
  Clean = 1,
  Dirty,
  UnderMaintenance,
  OutOfService,
}
