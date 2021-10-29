import { GeoLocation } from "./geoLocation";

export interface Address {
    street: string;
    suite: string;
    city: string;
    zipCode: string;
    geo: GeoLocation;
    
}