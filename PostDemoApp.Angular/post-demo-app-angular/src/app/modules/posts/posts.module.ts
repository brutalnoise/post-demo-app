import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { PostListComponent } from "./components/list/post-list.component";
import { PostListEntryComponent } from "./components/post-list-entry/post-list-entry.component";
import { PostsRoutingModule } from "./posts-routing.module";
import { CommonModule } from '@angular/common';
import { PostDetailsComponent } from "./components/details/post-details.component";

const components = [
  PostListComponent,
  PostListEntryComponent,
  PostDetailsComponent
];

// const services = [

// ];

const imports = [
  SharedModule,
  PostsRoutingModule
];

@NgModule({
  imports: [...imports],
  declarations: [...components],
  providers: [],
  exports: [...components]
})
export class PostsModule { }