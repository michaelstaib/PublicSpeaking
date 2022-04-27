export const random = (min = 0, max = 1_000) =>
  Math.floor(Math.random() * (max - min + 1) + min);
