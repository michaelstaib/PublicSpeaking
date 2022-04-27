import {SvgIcon} from '@mui/material';

export default function BearishIcon(props) {
  return (
    <SvgIcon viewBox="0 0 48 48" {...props}>
      <path
        fill="#F44336"
        stroke="none"
        d="M40 34h4v10h-4zm-6-5h4v15h-4zm-6 4h4v11h-4zm-6-8h4v19h-4zm-6 3h4v16h-4zm-6-4h4v20h-4zm-6-5h4v25H4z"
      />
      <g fill="#D32F2F" stroke="none">
        <path d="m34 13.2-4 4-10-10-5 5-7.6-7.6-2.8 2.8L15 17.8l5-5 10 10 4-4 6.1 6.1 2.8-2.8z" />
        <path d="M44 26h-9l9-9z" />
      </g>{' '}
    </SvgIcon>
  );
}
