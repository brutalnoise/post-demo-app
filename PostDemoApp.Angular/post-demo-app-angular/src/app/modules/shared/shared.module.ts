import { ModuleWithProviders, NgModule } from "@angular/core";
import { Configuration } from "./constants/configuration";

const services = [
  Configuration
]

@NgModule({
})

export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
        ...services
      ],
    };
  }
}