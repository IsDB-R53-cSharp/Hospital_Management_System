export class TestBills {
  constructor(
    public testBillId?: number,
    public testBillName?: string,
    public prescriptionID?: number,
    public price?: number,
    public NetPrice?: number,
    public isComplete?: boolean,
    public paidAmount?: number,
    public due?: number
  ) { }
}
