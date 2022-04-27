import {memo} from 'react';
import {useState} from 'react';
import {graphql, useLazyLoadQuery} from 'react-relay';

import SettingsCredentials from './SettingsCredentials';
import SettingsLinks from './SettingsLinks';
import SettingsProfile from './SettingsProfile';

export default memo(function SettingsContainer({cacheBuster}) {
  const data = useLazyLoadQuery(
    graphql`
      query SettingsContainerQuery {
        ...SettingsProfileFragment_query
      }
    `,
    {},
    {fetchKey: cacheBuster},
  );

  const [active, setActive] = useState('profile');

  return (
    <>
      <SettingsLinks active={active} onChange={setActive} />
      <SettingsCredentials active={active} onChange={setActive} />
      <SettingsProfile
        fragmentRef={data}
        active={active}
        onChange={setActive}
      />
    </>
  );
});
