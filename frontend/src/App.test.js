import { render, screen } from '@testing-library/react';
import App from './App';

test('renders header text', () => {
  render(<App />);
  const header = screen.getByText(/User Management/i);
  expect(header).toBeInTheDocument();
});
