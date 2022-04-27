import Error from 'next/error';

export const Dummy = (props) => (
  <Error statusCode="(ツ)" title="Keep Calm and Carry On" {...props} />
);
