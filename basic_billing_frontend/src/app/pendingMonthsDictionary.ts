const currentDate = new Date();
const currentMonth = currentDate.getMonth() + 1;
const currentYear = currentDate.getFullYear();
const months = {
  [`${currentYear}01`]: "January",
  [`${currentYear}02`]: "February",
  [`${currentYear}03`]: "March",
  [`${currentYear}04`]: "April",
  [`${currentYear}05`]: "May",
  [`${currentYear}06`]: "June",
  [`${currentYear}07`]: "July",
  [`${currentYear}08`]: "August",
  [`${currentYear}09`]: "September",
  [`${currentYear}10`]: "October",
  [`${currentYear}11`]: "November",
  [`${currentYear}12`]: "December",
};

const PendingMonths: { [key: string]: string } = {};
for (const key of Object.keys(months)) {
  const monthValue = key.slice(4, 6);
  if (parseInt(monthValue) >= currentMonth) {
    PendingMonths[key] = months[key];
  }
}

export { PendingMonths };