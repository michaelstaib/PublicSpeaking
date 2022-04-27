import {useState} from 'react';

export const useErrorHandler = (givenError) => {
  const [error, setError] = useState(null);

  if (givenError != null) throw givenError;
  if (error != null) throw error;

  return setError;
};
