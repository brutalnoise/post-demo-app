import { Post } from "./post";

export interface Comment {
    id: number;
    postId: number;
    post: Post;
    email: string;
    body: string;
}