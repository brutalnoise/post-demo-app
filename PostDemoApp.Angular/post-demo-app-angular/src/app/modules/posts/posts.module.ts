import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { PostListComponent } from "./components/list/post-list.component";
import { PostListEntryComponent } from "./components/post-list-entry/post-list-entry.component";
import { PostsRoutingModule } from "./posts-routing.module";
import { CommonModule } from '@angular/common';
import { PostDetailsComponent } from "./components/details/post-details.component";
import { CommentCardComponent } from "./components/comments/comment-card/comment-card.component";
import { CommentListComponent } from "./components/comments/comment-list/comment-list.component";
import { AddCommentComponent } from "./components/comments/add-comment/add-comment.component";
import { CommentEventEmitters } from "./events/commentEventEmitters";

const components = [
  PostListComponent,
  PostListEntryComponent,
  PostDetailsComponent,
  CommentCardComponent,
  CommentListComponent,
  AddCommentComponent
];

 const events = [
  CommentEventEmitters
];

const imports = [
  SharedModule,
  PostsRoutingModule
];

@NgModule({
  imports: [...imports],
  declarations: [...components],
  providers: [...events],
  exports: [...components]
})
export class PostsModule { }