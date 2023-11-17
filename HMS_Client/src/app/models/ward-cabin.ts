export class WardCabin {
    constructor(
        public wardCabinId?: number,
        public wardCabinName?: string,
        public wardCabinType?: WardCabinType,
        public Department?: number,
        public BedId?: number,
        
    ){}
}
export enum WardCabinType {
    Ward = 1,
    SingleCabin, 
    DoubleCabin 
    // Add more types as needed
  }
  
