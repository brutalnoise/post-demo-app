import { Address } from "cluster";
import { Company } from "./company";

export interface User {
    id: number;
    name: string;
    userName: string;
    email: string;
    address: Address;
    phone: string;
    webSite: string;
    company: Company;
}