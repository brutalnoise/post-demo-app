import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Configuration } from "../../shared/constants/configuration";
import { BaseHttpService } from "../../shared/services/baseHttp.service";
import { User } from "../../posts/intefraces/user";
@Injectable()
export class UserService extends BaseHttpService<User> {

    constructor(protected readonly http: HttpClient,
        protected readonly configuration: Configuration) {
            super(http, configuration, "User")
    }

}