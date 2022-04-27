import styled from '@emotion/styled';
import {Stack} from '@mui/material';

const Root = styled(Stack)`
  width: 100%;
  min-height: 200px;
  min-width: 100%;
  gap: 8%;
  scroll-snap-type: x mandatory;
  -webkit-overflow-scrolling: touch;
  overflow-x: scroll;
  overscroll-behavior-x: none;
  scrollbar-width: none;

  &::-webkit-scrollbar {
    display: none;
  }

  & > a:first-of-type {
    margin-left: 10%;
  }

  & > a:last-of-type {
    margin-right: 10%;
  }

  & > * {
    min-width: 80%;
    scroll-snap-align: center;
  }
`;

export const Carousel = (props) => (
  <Root direction="row" tabIndex={0} {...props} />
);
