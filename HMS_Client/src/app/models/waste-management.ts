
export class WasteManagement {
  constructor(
    public wasteID?: number,
    public wasteType?: number,
    public disposalDate?: string,
    public disposalMethod?: Date,
    public quantity?: number,
    public nextScheduleDate?: string,
    public contactNumber?: string
  ) { }
}
export enum WasteType {
  General = 1,
  Biological,
  Hazardous,
  Electronic,
  Pharmaceutical,
  Sharps,
  Chemical,
  Radiological
}
