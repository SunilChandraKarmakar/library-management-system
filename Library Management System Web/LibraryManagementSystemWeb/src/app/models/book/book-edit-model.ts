export class BookEditModel {
    id: number;
    title: string;
    ISBN: string;
    authorId: number;
    publishedDate: Date;
    availableCopies: number;
    totalCopies: number;
}