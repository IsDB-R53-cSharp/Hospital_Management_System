export class DrawerInfo {
  constructor(
    public drawerInfoID?: number,
    public receivedDate?: Date,
    public releaseDate?: Date,
    public isPatient?: boolean,
    public drawerID?: number,
    public drawer?: [],
    public patientID?: number,
    public patientRegister?: [],
    public unidentifiedDeadBodyID?: number,
    public unidentifiedDeadBody?: []
  ) { }
}
