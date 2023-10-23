export class TakenServices {
  constructor(
    public takenServiceId?: number,
    public takenServiceName?: string,
    public date?: Date,
    public patientID?: number,
    public price?: number,
    public isComplete?: boolean,
    public paidAmount?: number,
    public due?: number
  ) { }
}
