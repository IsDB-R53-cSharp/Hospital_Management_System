
export enum Gender {
  Male = 1,
  Female,
  Other,
  PreferNotToSay,
}
export class PatientRegister {
  constructor(
    public patientID?: number ,
    public patientIdentityNumber?: string ,
    public patientName?: string ,
    public gender?: Gender ,
    public address?: string ,
    public phoneNumber?: string ,
    public email?: string
    //public prescriptions: Prescription[] = [],
    //public indoorPatients: IndoorPatient[] = []
  ) { }
}








