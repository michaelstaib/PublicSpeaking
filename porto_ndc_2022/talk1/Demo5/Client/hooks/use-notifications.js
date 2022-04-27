import {useRouter} from 'next/router';
import {useEffect, useState} from 'react';

const Status = {
  ON: true,
  OFF: false,
};

export const useNotifications = (initial = Status.OFF) => {
  const router = useRouter();
  const [active, setActive] = useState(initial);

  useEffect(() => {
    router.events.on('routeChangeStart', () => {
      setActive(Status.OFF);
    });
  }, []);

  const handler = (next) => () => {
    setActive(next);
  };

  return {
    active,
    show: handler(Status.ON),
    hide: handler(Status.OFF),
  };
};
