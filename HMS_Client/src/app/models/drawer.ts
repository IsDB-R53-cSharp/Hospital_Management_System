
export class Drawer {
  constructor(
    public drawerID?: number,
    public drawerNo?: string,
    public drawerCondition?: drawerCondition,
    public isOccupied?: boolean,
    public morgueID?: number,
    public morgue?: []
  ) { }
}
export enum drawerCondition {
  Clean = 1,
  Dirty,
  UnderMaintenance,
  OutOfService,
}
