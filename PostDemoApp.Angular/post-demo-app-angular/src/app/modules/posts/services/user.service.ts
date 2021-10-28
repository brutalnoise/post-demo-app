import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Configuration } from "../../shared/constants/configuration";
import { Observable } from "rxjs";
import { User } from "../intefraces/user";

@Injectable()
export class UserService {
    private baseUrl: string;

    constructor(private readonly http: HttpClient,
        private readonly configuration: Configuration) {
        this.baseUrl = configuration.buildEndpoint('User/');
    }

    public GetList(): Observable<User[]> {
        return this.http.get<User[]>(`${this.baseUrl}List`);
    }
}