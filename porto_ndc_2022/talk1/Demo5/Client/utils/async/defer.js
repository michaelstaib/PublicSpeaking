export const defer = (value, wait) =>
  new Promise((resolve) => {
    setTimeout(() => {
      resolve(value);
    }, wait);
  });
