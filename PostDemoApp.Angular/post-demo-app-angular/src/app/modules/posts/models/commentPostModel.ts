import { Comment } from "../interfaces/comment";
import { Post } from "../interfaces/post";

export class CommentPostModel implements Comment {
    id: number;
    postId: number;
    post: Post;
    email: string;
    body: string;

    constructor(postId: number, email: string, body: string) {
        this.id = 0;
        this.postId = postId;
        this.email = email;
        this.body = body;
    }

}