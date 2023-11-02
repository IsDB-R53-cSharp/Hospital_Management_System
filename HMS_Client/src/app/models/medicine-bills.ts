export class MedicineBills {
  constructor(
    public medicineBillId?: number,
    public medicineName?: string,
    public prescriptionID?: number,
    public medicineCount?: number,
    public price?: number,
    public netPrice?: number,
    public isComplete?: boolean,
    public paidAmount?: number,
    public due?: number
  ) { }
}
