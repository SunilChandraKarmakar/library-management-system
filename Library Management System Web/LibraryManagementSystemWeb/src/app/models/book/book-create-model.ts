export class BookCreateModel {
    title: string;
    ISBN: string;
    authorId: number;
    publishedDate: Date;
    availableCopies: number;
    totalCopies: number;
}