import { DetailEmail } from "./detail-email";

export interface Email {

  idEmail:string,
  specialId?:string,
  dateLog?:string,
  detailEmail : DetailEmail[],
  emailType:string,


}
