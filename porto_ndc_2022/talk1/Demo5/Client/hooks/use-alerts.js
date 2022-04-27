import {useRouter} from 'next/router';

const Status = {
  ON: 'on',
  OFF: 'off',
};

export const useAlerts = () => {
  const router = useRouter();

  const {pathname, query} = router;

  const active = query.alerts === Status.ON;

  const handler = (alerts) => () => {
    router.replace({pathname, query: {...query, alerts}}, undefined, {
      shallow: true,
    });
  };

  return {
    active,
    show: handler(Status.ON),
    hide: handler(Status.OFF),
  };
};
