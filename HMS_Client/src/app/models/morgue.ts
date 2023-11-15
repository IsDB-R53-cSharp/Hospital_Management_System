export class Morgue {
  constructor(
    public morgueID?: number,
    public morgueName?: string,
    public capacity?: number,
    public isolationCapability?: boolean,
    public drawers?:[]
  ) { }
}
