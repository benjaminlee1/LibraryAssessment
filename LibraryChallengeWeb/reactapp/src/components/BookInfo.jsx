import React from "react";

// Title
// Author
// ISBN
// Due date -> Border Color:
//              - Orange: Due Today
//              - Red: Over due
//              - Green: Not due yet.

export default function BookInfo({ book, due }) {
  function getDueText(val) {
    if (val === "green") {
      return "Available";
    } else if (val === "red") {
      return "Overdue";
    } else if (val === "orange") {
      return "Due Today";
    } else {
      return "Lent out";
    }
  }

  return (
    <div style={{ backgroundColor: due }}>
      <h1>{book.title}</h1>
      <h2>By: {book.author}</h2>
      <p>{getDueText(due)}</p>
      <p>{book.isbn}</p>
    </div>
  );
}
